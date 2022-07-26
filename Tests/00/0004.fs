module T0004

open Xunit

[<Fact>]
let ``Solution should be correct for real case`` () =
    Assert.Equal(S0004.solution 3, 906609)

[<Fact>]
let ``Solution should be correct for trivial case`` () =
    Assert.Equal(S0004.solution 2, 9009)
