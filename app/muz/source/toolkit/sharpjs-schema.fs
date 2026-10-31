module Muz.Source.Toolkit.SchemaJs

let file = """// Deliberately small schema subset used by this local stdio server. Keep the
// advertised schemas and validation together; unknown arguments are never ignored.
export const string = { type: 'string' };
export const number = { type: 'number' };
export const bool = { type: 'boolean' };
export const integer = (minimum, maximum) => ({ type: 'integer', minimum, maximum });
export const object = (properties, required = []) => ({ type: 'object', properties, required, additionalProperties: false });
export const array = items => ({ type: 'array', items, maxItems: 1000 });
export function validate(value, schema, path = 'arguments') {
  if (schema.type === 'object') {
    if (!value || typeof value !== 'object' || Array.isArray(value)) throw Error(`${path} must be an object.`);
    for (const key of schema.required || []) if (value[key] === undefined) throw Error(`${path}.${key} is required.`);
    for (const [key, child] of Object.entries(value)) {
      const rule = schema.properties?.[key] || (typeof schema.additionalProperties === 'object' ? schema.additionalProperties : null);
      if (!rule && schema.additionalProperties === false) throw Error(`Unknown argument: ${path}.${key}`);
      if (rule) validate(child, rule, `${path}.${key}`);
    }
  } else if (schema.type === 'array') {
    if (!Array.isArray(value) || (schema.maxItems && value.length > schema.maxItems)) throw Error(`${path} must be an array with at most ${schema.maxItems} items.`);
    for (let i = 0; i < value.length; i++) validate(value[i], schema.items, `${path}[${i}]`);
  } else if (schema.type === 'integer' ? !Number.isSafeInteger(value) : schema.type === 'number' ? !Number.isFinite(value) : typeof value !== schema.type) throw Error(`${path} must be ${schema.type}.`);
  if (schema.enum && !schema.enum.includes(value)) throw Error(`${path} must be one of ${schema.enum.join(', ')}.`);
  if (schema.minimum !== undefined && value < schema.minimum || schema.maximum !== undefined && value > schema.maximum) throw Error(`${path} is outside its allowed range.`);
  if (schema.maxLength && value.length > schema.maxLength) throw Error(`${path} exceeds ${schema.maxLength} characters.`);
}
"""

let render() = file
