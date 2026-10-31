module Muz.Source.Src.DataWorkerJs

let file = """import { embeddedFragment, resolveProjectLink, resolveGist } from './links.js';
self.onmessage = async ({ data: { id, operation, input } }) => {
  try {
    const result = operation === 'share' ? embeddedFragment(input) : operation === 'gist' ? await resolveGist(input) : await resolveProjectLink(input);
    self.postMessage({ id, result });
  } catch (e) { self.postMessage({ id, error: e.message }); }
};
"""

let render() = file
