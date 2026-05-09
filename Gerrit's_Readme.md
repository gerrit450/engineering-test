# Gerrits documentation [draft]

This document contains all my notes for this exercise

## Changes

### QualityControl.cs refactor
This is one of the changes I refactored. I seperated the business logic of the `Program.cs` by taking the `UpdateQuality` method into its own class `QualityControl`.
The benefits of this change is twofold. By seperating the busines logic, allows the ability to write unit tests on the `UpdateQuality` method. This allows me confidently update
the core logic while unit testing is used to ensure I dont introduce any breaking change. This change also increases readability of the `Program.cs` file.


## Questions