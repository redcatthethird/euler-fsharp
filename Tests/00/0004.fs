namespace T00
module T0004 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(906609, S0004.solution 3)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(9009, S0004.solution 2)
