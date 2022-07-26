module T0003

open Xunit

[<Fact>]
let ``Solution should be correct for real case`` () =
    Assert.Equal(S0003.solution 600851475143L, 6857)

[<Fact>]
let ``Solution should be correct for trivial case`` () =
    Assert.Equal(S0003.solution 13195L, 29)
