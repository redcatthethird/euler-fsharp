namespace T00
module T0008 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(23514624000L, S0008.solution 13)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(5832L, S0008.solution 4)
