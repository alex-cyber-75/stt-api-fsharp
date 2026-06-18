namespace STTApi

open System
open System.IO
open System.Threading.Tasks
open Whisper

/// Simple wrapper around Whisper.Net to transcribe audio from a byte array.
/// The actual Whisper.Net API may differ; adjust accordingly.
module Transcriber =
    let transcribe (audioBytes: byte[]) : Task<string> =
        // Whisper.Net typically requires a file path; write to temp file.
        let tempFile = Path.GetTempFileName()
        File.WriteAllBytes(tempFile, audioBytes)
        // Assuming Whisper.Net exposes a synchronous Transcribe method.
        // Replace with the actual API call.
        let result = Whisper.Transcribe(tempFile)
        // Clean up temp file
        File.Delete(tempFile)
        Task.FromResult(result)