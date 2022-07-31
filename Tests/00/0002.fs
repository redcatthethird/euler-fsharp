namespace T00
module T0002 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(4613732, S0002.solution 4000000)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(44, S0002.solution 90)