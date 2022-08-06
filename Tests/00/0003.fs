namespace T00
module T0003 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(6857UL, S0003.solution 600851475143UL)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(29UL, S0003.solution 13195UL)
