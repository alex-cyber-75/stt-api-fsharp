namespace Tests
open NUnit.Framework
open STTApi
open System.Threading.Tasks

[Test]
let ``Transcriber returns known phrase`` () : Task =
    async {
        let mp3Path = __SOURCE_DIRECTORY__ + "/hello_world.mp3"
        let dummyBytes = System.IO.File.ReadAllBytes(mp3Path)
        let! result = Transcriber.transcribe dummyBytes
        Assert.AreEqual("Hello world", result)
    } |> Async.StartAsTask
