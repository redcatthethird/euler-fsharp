namespace T00
module T0010 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(142913828922L, S0010.solution 2000000u)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(17L, S0010.solution 10u)
