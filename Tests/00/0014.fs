namespace T00
module T0014 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(837799UL, S0014.solution 1000000UL)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(9UL, S0014.solution 13UL)
