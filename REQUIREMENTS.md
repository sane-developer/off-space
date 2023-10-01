# V1

### Goal

Outpost management system implementation.

### Glossary

<ul>
  <li>Clusters - Groups of merged verven blocks,</li>
  <li>Singles - Blocks which are not parts of any cluster.</li>
</ul>

### Functionality

<ul>
  <li>Creating outposts,</li>
  <li>Removing outposts,</li>
  <li>Changing outposts names,</li>
  <li>Changing outposts locations,</li>
  <li>Associating blocks with outposts,</li>
  <li>Detaching blocks from outposts,</li>
  <li>Merging blocks inside outposts,</li>
  <li>Splitting blocks inside outposts.</li>
</ul>

### Assumptions: Verven blocks

<ul>
  <li>Each block has shape of a cube,</li>
  <li>Each block is reusable, it cannot be disposed,</li>
  <li>Each block may be unused, meaning it is waiting to be attached to an outpost.</li>
</ul>

### Restrictions: Creating outposts

Action is not permitted when the name of the outpost has already been used.

### Restrictions: Removing outposts

Action is not permitted when the outpost has any blocks associated with it.

### Restrictions: Changing outposts names

Action is not permitted when the name of the outpost has already been used.

### Restrictions: Changing outposts locations

Action is not permitted when the new location is not Bulgaria, Germany, Italy, Romania or Switzerland.

### Restrictions: Associating blocks with outposts

Action is not permitted when:

<ul>
  <li>The depth of the building changed,</li>
  <li>The count of used blocks reached 24,</li>
  <li>The width or height of the outpost exceeded 7,</li>
  <li>The block is unreachable from any other block.</li>
</ul>

### Restrictions: Detaching blocks from outposts

Action is not permitted when:

<ul>
  <li>The block is merged with another,</li>
  <li>The absence of the block rendered any other unreachable.</li>
</ul>

### Restrictions: Merging blocks in outposts

Action is not permitted when:

<ul>
  <li>When both blocks do not share a side,</li>
  <li>When both blocks are parts of different clusters.</li>
  <ul>
    <li>This feature will be added in the future versions.</li>
  </ul>
</ul>

### Restrictions: Splitting blocks in outposts

Action is not permitted when:

<ul>
  <li>The block is not part of a merged figure,</li>
  <li>The absence of this block rendered any other unreachable within the cluster.</li>
</ul>
