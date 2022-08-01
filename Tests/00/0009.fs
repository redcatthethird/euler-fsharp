namespace T00
module T0009 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct`` () =
        Assert.Equal(31875000, S0009.solution)