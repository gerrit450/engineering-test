# Gerrits documentation

This document contains all my notes for exercise 2.

## Changes

### UpdateQuality refactor

* **Original** UpdateQuality mermaid diagram workflow: [Link to document](BeforeUpdatingQualityRules.md) (Created using copilot)
* **New** UpdateQuality mermaid diagram workflow: [Link to document](AfterUpdatingQualityRules.md) (Created using copilot)

For the UpdateQuality method, I decided to go with a hybrid of a strategy and factory pattern. I created an `IUpdateQualityStrategy` interface that defines the contract for updating the properties of an item.
Every item including the `AgedBrieStrategy` implement this interface and specifies the rules for updating the properties of a item.

Once the strategies has been defined, I created a `ItemFactory` class that is responsible for instantiating the appropriate strategy based on the `item name`. The factory would create a new instance of the appropiate item.
Any items that does not contain any special rules, follow the `NormalItemStrategy.cs` which contains the default configurations.

This gives me the following advantages:
* Allows me to easily add new item strategies in the future without modifying existing code of other strategies, adhering to the Open/Closed principle.
* Factory pattern will give me the correct strategy, as long as I assign the correct item.

There are however, cons to this design:
* Difficult to scale if we need 50 items with specific rules. Would need to create a new strategy for each special item.
* Reigstration overhead: For every new strategy we want to use, we would need to add it to the `ItemFactory`.

### Tests

From a test perspective, this design allows me to individually test each strategy for the different strategies types, ensuring that the quality update logic is correct for each type.
For the test strategy, I followed the triple AAA pattern (Arrange, Act, Assert) to structure my unit tests, making them clear and easy to understand.
When I started with the `ConjuredItemStrategy`, I followed a TDD approach where I created my unit tests that contains my requirements and then I created my strategy, ensuring that
the logic I add, does not break the requirements.

Added unit testing for the behaviour of certain items:
- Normal item:
	- Test that item quality never goes below zero
	- Test that item sellin value decreases by 1 each day
- Age brie:
	- Test that item quality increases by 1 each day
	- Test that item quality increases by 2 when past the due date
	- Test that item quality never goes above 50
- Sulfuras/legendary:
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

2. Based on this rule: `Once the sell by date has passed, Quality degrades twice as fast`. If a conjured item is past its sell by date, does it degrade by 4?