namespace T00
module T0001 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(233168, S0001.solution 1000)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(23, S0001.solution 10)