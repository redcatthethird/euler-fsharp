namespace T00
module T0005 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(232792560UL, S0005.solution 20UL)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(2520UL, S0005.solution 10UL)
