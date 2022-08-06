namespace T00
module T0010 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(142913828922UL, S0010.solution 2000000UL)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(17UL, S0010.solution 10UL)
