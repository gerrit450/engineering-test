# Gerrits documentation [draft]

This document contains all my notes for this exercise

## Changes

* Original UpdateQuality workflow: [Link to document](BeforeUpdatingQualityRules.md) (Created using copilot)
* New UpdateQuality workflow: [Link to document](AfterUpdatingQualityRules.md) (Created using copilot)

### UpdateQuality refactor
This is one of the changes I refactored. I seperated the business logic of the `Program.cs` by taking the `UpdateQuality` method into its own class `QualityControl`.
The benefits of this change is twofold. By seperating the busines logic, allows the ability to write unit tests on the `UpdateQuality` method. This allows me confidently update
the core logic while unit testing is used to ensure I dont introduce any breaking change. This change also increases readability of the `Program.cs` file.

For the internal logic of each item, I decided on using a combination of a design and factory pattern.

### Unit testing
Added unit testing for the behaviour of certain items:
- Normal item:
	- Test that item quality never goes below zero
	- Test that item sellin value decreases by 1 each day
- Age brie:
	- Test that item quality increases by 1 each day
	- Test that item quality increases by 2 when past the due date
	- Test that item quality never goes above 50
- Sulfuras:
	- Test that item quality never changes
	- Test that item sellin value never changes
- Backstage pass:
	- Test that item quality increases by 1 when there are more than 10 days
	- Test that item quality increases by 2 when there are 10 days or less
	- Test that item quality increases by 3 when there are 5 days or less
	- Test that item quality drops to 0 after the concert
- Conjured item:
	- Test that item quality degrades by 2 each day
	- Test that item quality degrades by 4 when past the due date
	- Test that item quality never goes below zero
	- Test that item sellin value decreases by 1 each day


## Questions/Answers

1. For the item `Elixir of the Mongoose`, would this be considered a `conjured` or a `legendary type`?
  _I did not see the references to WOW! So this is a consumable item so I would make the assume that this is a `normal item` type._

2.Based on this rule: `Once the sell by date has passed, Quality degrades twice as fast`. If a conjured item is past its sell by date, does it degrade by 4?