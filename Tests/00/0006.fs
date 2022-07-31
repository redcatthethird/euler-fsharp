namespace T00
module T0006 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(25164150, S0006.solution 100)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(2640, S0006.solution 10)
