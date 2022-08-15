namespace T00
module T0013 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct`` () =
        Assert.Equal("5537376230", S0013.solution)
