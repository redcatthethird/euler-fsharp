namespace T00
module T0007 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(104743, S0007.solution 10001)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(13, S0007.solution 6)
