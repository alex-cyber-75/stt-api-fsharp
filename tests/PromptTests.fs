namespace Tests
open NUnit.Framework
open System.IO

[<TestFixture>]
module PromptTests =

    [<Test>]
    let ``Prompt test placeholder`` () =
        // Placeholder: load prompt mp3 from data folder
        let promptPath = Path.Combine(__SOURCE_DIRECTORY__, "data", "simple_prompt_EN.mp3")
        let _ = File.ReadAllBytes(promptPath)
        // TODO: add assertions later
        ()
