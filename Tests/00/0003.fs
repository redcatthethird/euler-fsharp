namespace T00
module T0003 =

    open Xunit

    [<Fact>]
    let ``Solution should be correct for real case`` () =
        Assert.Equal(6857L, S0003.solution 600851475143L)

    [<Fact>]
    let ``Solution should be correct for trivial case`` () =
        Assert.Equal(29L, S0003.solution 13195L)
