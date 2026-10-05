# Task 2.1 — IReadOnlyDictionary & SortedDictionary

## IReadOnlyDictionary<TKey, TValue>

`IReadOnlyDictionary<TKey, TValue>` is an interface that represents a dictionary that can be used for reading only.

It allows us to access values using their keys, check if a key exists, and iterate through the collection, but it does not provide methods like `Add` or `Remove`.

### IReadOnlyDictionary vs Dictionary

The main difference is that `Dictionary<TKey, TValue>` is a modifiable collection, while `IReadOnlyDictionary<TKey, TValue>` exposes the dictionary through a read-only interface.

A public method can return `IReadOnlyDictionary` instead of `Dictionary` when we want to allow the caller to read the data without giving them operations to modify the collection through the returned interface.

This also makes the public API clearer because the caller only gets the operations that are needed.

One important point is that `IReadOnlyDictionary` does not make the original dictionary immutable. If the original dictionary is changed internally, the data seen through the read-only interface can also change.

---

## SortedDictionary<TKey, TValue>

`SortedDictionary<TKey, TValue>` is a dictionary that keeps its elements sorted by their keys.

Unlike a normal `Dictionary`, when we iterate over a `SortedDictionary`, the keys are returned in sorted order.

### SortedDictionary vs Dictionary

The main difference is the way they store and access their data.

`Dictionary<TKey, TValue>` uses hashing, so its average lookup time is `O(1)`.

`SortedDictionary<TKey, TValue>` uses a binary search tree, so lookup takes `O(log n)`.

This means that `Dictionary` is usually faster when the main requirement is finding values by their keys.

I would choose `SortedDictionary` when I need the keys to always be sorted while working with the collection, even though its lookup is slower than `Dictionary`.

### When would I choose each one?

- `Dictionary` when fast lookup is the main requirement and ordering is not important.
- `SortedDictionary` when I need the keys to stay sorted and I want to enumerate the collection in sorted order.


# Task 2.2 — Pick the Collection

### S1 — Find a student by national ID
**Scenario:** Find a student by national ID — thousands of times a day.

**Collection:** `Dictionary`

**Why:** It provides fast lookup by national ID, which is important when searching thousands of times a day.

---

### S2 — Keep course tags
**Scenario:** Keep the tags of a course. The same tag must never be stored twice.

**Collection:** `HashSet`

**Why:** It automatically prevents duplicate tags from being stored.

---

### S3 — Keep student's grades
**Scenario:** Keep a student's grades in the order they were entered. The same grade can appear more than once.

**Collection:** `List`

**Why:** It keeps grades in insertion order and allows duplicate values.

---

### S4 — Return course price list
**Scenario:** A public method returns the course price list. Callers can read prices but must not add or change any.

**Collection:** `IReadOnlyDictionary`

**Why:** It allows callers to read the price list without providing operations to add or remove entries through the returned interface.

---

### S5 — Timetable by session start time
**Scenario:** A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.

**Collection:** `SortedDictionary`

**Why:** It keeps sessions sorted by their start time while sessions can be added at any time.

---

### S6 — Results returned from a method
**Scenario:** A method returns results that the caller only loops over once — and may stop early.

**Collection:** `IEnumerable`

**Why:** It allows the method to return results lazily so the caller can iterate once and stop early without requiring all results to be stored first.