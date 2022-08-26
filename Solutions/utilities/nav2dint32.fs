module Nav2DInt32

[<Struct; StructuredFormatDisplay("({X}, {Y})")>]
type Vector2 =
    { X: int; Y: int }
    static member (+) (a, b) = { X = a.X + b.X; Y = a.Y + b.Y }
    static member (-) (a, b) = { X = a.X - b.X; Y = a.Y - b.Y }
    static member (~-) v = { X = -v.X; Y = -v.Y }
    static member (*) (s, v) = { X = s * v.X; Y = s * v.Y }

    static member Zero = { X = 0; Y = 0 }
    static member UnitX = { X = 1; Y = 0 }
    static member UnitY = { X = 0; Y = 1 }

type Direction =
    | East
    | NorthEast
    | North
    | NorthWest
    | West
    | SouthWest
    | South
    | SouthEast

let screenSpaceOffset = function
    | East -> Vector2.UnitX
    | NorthEast -> Vector2.UnitX - Vector2.UnitY
    | North -> -Vector2.UnitY
    | NorthWest -> -Vector2.UnitX - Vector2.UnitY
    | West -> -Vector2.UnitX
    | SouthWest -> -Vector2.UnitX + Vector2.UnitY
    | South -> Vector2.UnitY
    | SouthEast -> Vector2.UnitX + Vector2.UnitY

type Quadrant =
    | Q1
    | Q2
    | Q3
    | Q4

let isInScreenQuadrantOf a b = function
    | Q1 -> a.Y <= b.Y && a.X >= b.X
    | Q2 -> a.Y <= b.Y && a.X <= b.X
    | Q3 -> a.Y >= b.Y && a.X <= b.X
    | Q4 -> a.Y >= b.Y && a.X >= b.X
    
[<Struct; StructuredFormatDisplay("[N⨯N]")>]
type VirtualMatrix2 =
    { N: int }

    member this.End = { X = this.N - 1; Y = this.N - 1 }
    member this.IsInRange v = isInScreenQuadrantOf v Vector2.Zero Q4 && isInScreenQuadrantOf v this.End Q2