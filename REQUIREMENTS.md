# V1

### Goal

Delivery of a back-end system that allows the user to:

<ul>
  <li>Create a new outpost,</li>
  <li>Remove an existing outpost,</li>
  <ul>
    <li>This action is only possible when there are no blocks associated with the outpost.</li>
  </ul>
  <li>Change an outpost name,</li>
  <li>Change an outpost location,</li>
  <ul>
    <li>This action is only possible when there are no blocks associated with the outpost.</li>
  </ul>
  <li>Attach a block to an outpost,</li>
  <li>Detach a block from an outpost,</li>
  <li>Change an attached block's position within an outpost.</li>
</ul>

### Assumptions: The blocks

<ul>
  <li>Each block may be a "root",</li>
  <li>Each block is of the same size,</li>
  <li>Each block is of the same shape,</li>
  <li>Each block can be attached to an outpost,</li>
  <li>Each block can be detached from an outpost,</li>
  <li>Each block must be able to reach any other block,</li>
  <li>There are only 100 available blocks for outposts constructions.</li>
</ul>

### Assumptions: The "root" blocks

<ul>
  <li>The root block must be placed on the lowest possible level,</li>
  <li>The root block may not be moved until it is the last block in the outpost,</li>
  <li>The root block cannot be detached until it is the last block in the outpost.</li>
</ul>

In case of multiple blocks on the ground, it is required to define which one is the root.

### Assumptions: The outposts

<ul>
  <li>Each outpost must have a unique name,</li>
  <li>Each outpost may contain up to 25 blocks,</li>
  <li>Each outpost may only have one root block,</li>
  <li>Each outpost may only be expanded vertically and horizontally,</li>
  <li>Each outpost may reach up to 7 levels vertically and horizontally.</li>
</ul>
