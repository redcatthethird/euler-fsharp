module Memo

open System.Collections.Generic

let memoize f =
    let cache = Dictionary<_,_>()
    fun key ->
        match cache.TryGetValue(key) with
        | (true, value) -> value
        | _ ->
            let value = f key
            cache.Add (key, value)
            value

let memoizeRec f =
    let cache = Dictionary<_, _>();
    let rec g key = h key
    and h key =
        match cache.TryGetValue(key) with
        | (true, value) -> value
        | _ ->
            let value = f g key
            cache.Add(key, value)
            value
    g

let memoize1D ni invalid f =
    let cache = Array.create ni invalid
    let rec g key = h key
    and h key =
        if 0 <= key && key < ni then
            match cache.[key] with
            | value when value <> invalid -> value
            | _ ->
                let value = f g key
                cache.[key] <- value
                value
        else
            f g key
    g