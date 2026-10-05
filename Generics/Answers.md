## Step 2 — A Store for Courses

### What is the same?

Both `StudentStore` and `CourseStore` use a `List` to store their items and provide the same four methods: `Add`, `GetById`, `GetAll`, and `Remove`.

### What is different?

`StudentStore` works specifically with `Student`, while `CourseStore` works specifically with `Course`. The properties of the stored objects are also different.

## Step 3 — One Class for Both

### Why does GetById not compile?

The `Store<T>` class works with a generic type `T`, but the compiler does not know that `T` has an `Id` property.

When `GetById` tries to access `item.Id`, the compiler rejects it because `T` could be any type, and not every type has an `Id` property.

### Compiler Error

`'T' does not contain a definition for 'Id' and no accessible extension method 'Id' accepting a first argument of type 'T' could be found (are you missing a using directive or an assembly reference?)`

To solve this problem, we need to tell the compiler that `T` must have an `Id`. This will be done in Step 4 using the `IHasId` interface and a generic constraint.
## Step 7 — Prove it in Main

### Why must `Store<string>` not compile?

`Store<T>` has the generic constraint:

`where T : IHasId`

This means that any type used with `Store<T>` must implement `IHasId`.

`string` does not implement `IHasId`, so `Store<string>` must not compile.

```csharp
// Store<string> stringStore = new(); // must NOT compile
```

### What is the common name for the kind of class you built in Steps 4 and 5?

A common name for this kind of class is a **Repository**.

Because the class is generic and can work with different entity types, it can be called a **Generic Repository**.