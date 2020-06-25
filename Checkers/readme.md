# Checkers game

## Change list

25.06.2020 - added ability for CPU to capture, added on screen display of whose turn it is

## Planned features

- refined AI
- when a piece makes it to the other end it becomes a "double" that can move backwards

## Bug list

- when a capture is made, only the capturing piece should be able to take another move
- in some circumstances, black piece moves into the same square as white piece
- when calculating captures near the other end of the boar an index out of range exception happens