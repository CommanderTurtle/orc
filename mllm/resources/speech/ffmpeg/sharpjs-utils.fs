module MLLM.Resources.Speech.Ffmpeg.UtilsJs

let file = """/**
 * Generate an unique message ID.
 */
export const getMessageID = (() => {
    let messageID = 0;
    return () => messageID++;
})();
"""

let render() = file
