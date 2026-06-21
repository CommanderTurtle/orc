module ConvertedFiles.Src.Lib.UtilsTs

let file = """import { clsx, type ClassValue } from "clsx"
import { twMerge } from "tailwind-merge"

export function cn(...inputs: ClassValue[]) {
  return twMerge(clsx(inputs))
}
"""

let render() = file
