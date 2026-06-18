namespace Tests
open NUnit.Framework

[<TestFixture>]
module SimpleTest =

    [<Test>]
    let ``Simple true test`` () =
        Assert.IsTrue(true)
