namespace T00
module T0005 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(232792560, S0005.solution 20)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(2520, S0005.solution 10)
