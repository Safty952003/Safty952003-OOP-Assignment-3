# Part 03 — answers

---

## BlockedUsers

- Time complexity before:
  - O(N × M)

- Time (ms) before:
  - 20 ms

- What did you change?
  - Changed the blocked IDs lookup from `List<int>.Contains()` to a `HashSet<int>`.
  - This makes checking whether an ID is blocked much faster.

- Time complexity after:
  - O(N + M)

- Time (ms) after:
  - 1 ms

---

## Students

- What was the problem?
  - `StudentCatalog` created 1,000,000 students even though `Program.cs` only printed the first 3 students.

- What did you change?
  - Changed `GetAllStudents()` to return `IEnumerable<Student>` and used `yield return` to create students lazily.
  - This allows the enumeration to stop after the first 3 students without creating the remaining students.
