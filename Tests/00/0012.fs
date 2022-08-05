namespace T00
module T0012 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(28, S0012.solution 5)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(1, S0012.solution 500)
