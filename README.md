# AB Sprite Editor

## Contents

* [Introduction](#Introduction)
* [Licence](#Licence)
	* [Licence Permissions](#Licence-Permissions)
* [Platforms](#Platforms)
* [Contributing](#Contributing)
	* [Feature Requests](#Feature-Requests)
	* [Code Contributions](#Code-Contributions)
	* [Bug Reports](#Bug-Reports)
* [Features](#Features)
	* [Existing Features](#Existing-Features)
	* [Planned Features](#Planned-Features)
	* [Vetoed Features](#Vetoed-Features)
* [Tutorial](#Tutorial)
* [Frequently Asked Questions](#Frequently-Asked-Questions)

## Introduction

This software is a sprite converter and editor intended for use with the [Arduboy](https://www.arduboy.com/) game console.

It is written in [C#](https://en.wikipedia.org/wiki/C_Sharp_(programming_language)) with the [WinForms API](https://en.wikipedia.org/wiki/Windows_Forms).

Please note that this software is not intended to replace a proper image editor like GIMP, it is intended to provide only basic editing features. If you need advanced features like layers, please use another image editor in conjunction with this software.

Other relevant information can be found on [the forum thread](https://community.arduboy.com/t/ab-sprite-editor-wip-preview/10374).

## Licence

The software is available under the [Apache 2.0](https://www.apache.org/licenses/LICENSE-2.0.html) licence.

Be sure to also read [the licence information for the associated resources](https://github.com/Pharap/ABSpriteEditor/tree/master/ABSpriteEditor/ABSpriteEditor/Resources/README.md#Licence).

### Licence Permissions

You **may**
* Create derivative works from the software

You **must**
* Reatain all copyright and licence notices
* Provide recepients of this software or derivative software a copy of the Apache 2.0 licence
* Ensure that any modified files contain a _prominent_ notice stating that you have modified the files

## Platforms

At the moment, only Windows binaries are provided.

If you wish to volunteer to provide binaries for other platforms (e.g. compiled with Mono) then please raise an issue.

## Contributing

### Feature Requests

Before making a feature request, please make sure to check that the feature has not already been requested, both in [the issues](https://github.com/Pharap/ABSpriteEditor/issues/) and on [the forum thread](https://community.arduboy.com/t/ab-sprite-editor-wip-preview/10374). If it has, you would be better off giving your support to the initial request than instating a new one.

If you would like to make a feature request, please either [raise an issue](https://github.com/Pharap/ABSpriteEditor/issues/new), leave a comment on [the forum thread](https://community.arduboy.com/t/ab-sprite-editor-wip-preview/10374), or send me a PM over on [the forum](https://community.arduboy.com/).

Please bear in mind that I am only one person, and that I like to retain creative control of my software, so I may dismiss feature requests that I am unsatisfied with or believe would take too much work for me to either implement or review. (If this dissatisfies you, feel free to fork the software and add your desired feature to your personal fork.)

### Code Contributions

Before attempting to make any kind of PR, _please_ raise an issue first to explain your intentions and discuss the implementation. Discussing a feature, bugfix or other contribution _prior_ to the production of the actual code helps to prevent mistakes or conflicts of intention by allowing time for communication, discussion and decision making. If a PR is created without any prior discussion, there is a high chance it will be rejected.

In the immortal words of Donald Knuth:
> "Always remember, however, that there’s usually a simpler and better way to do something than the first way that pops into your head."  
> \- Donald Knuth (1986), “The METAFONTbook”

### Bug Reporting

If you would like to report a bug, please either [raise an issue](https://github.com/Pharap/ABSpriteEditor/issues/new), leave a comment on [the forum thread](https://community.arduboy.com/t/ab-sprite-editor-wip-preview/10374), or send me a PM over on [the forum](https://community.arduboy.com/).

## Features

### Existing Features

These are features that have already been implemented and are present and (in most cases) presumed correct within the software. Some features may have known bugs or limitations.

#### Colours

* Black
* White
* Transparent

#### Tools

* Pencil - Fills a single pixel at a time, can be dragged
* Flood Fill - Your standard 'fill a connected group of same-colour pixels' flood-fill algorithm
* Outline Rectangle - Draws an unfilled rectangle, thus an 'outline' of a rectangle
* Fill Rectangle - Draws a filled rectangle, thus a solid block of colour

#### Actions

* Flip Horizontally - Flips the image around the X axis so that pixels above are swapped with pixels below
* Flip Vertically - Flips the image around the Y axis so that pixels on the left are swapped with pixels on the right

#### Editor Panel

* Drag the canvas around with the middle mouse button
* Zoom in and out with the scroll wheel
	* A little bit tempermental at the moment because the edit control must have focus first due to a quirk of WinForms
* Automatic zoom
	* When a sprite frame is selected for editing, the control defaults to a centralised view of the image at the largest scale in which it will fit into the edit box

#### Saving and Loading

* Sprite data can be saved to `.xml` files
* Sprite data can be loaded from `.xml` files

#### Exporting

Sprites can only be exported to `.h` files

* Export to various sprite formats
	* Export sprite without mask (`Sprites::drawOverwrite`)
	* Export sprite with interleaved mask (`Sprites::drawPlusMask`)
	* Export sprite with external mask (`Sprites::drawExternalMask`)
	* Export to uncompressed bitmap (`Arduboy2::drawBitmap`)
	* Export to compressed bitmap (`Arduboy2::drawCompressed`)
* It is possible to designate a licence text to be included near the top of the generated `.h` file
* If the generated C++ code would violate the one definition rule, a message box appears to warn the user and give them chance to correct this or to continue generating the code anyway

#### Tree View

* Renaming frames, sprites and namespaces
	* They can be named either by clicking twice on a tree node's name box or by using <kbd>F2</kbd>
* Drag files into the tree view to import them
	* Dragging onto a namespace or the main file node will generate a new sprite of the appropriate size
	* Dragging onto a sprite adds frames to the sprite if they are of a suitable size
	* Dragging onto a sprite frame will overwrite a span of frames, and add new frames if more are needed
* Reordering frames, sprites and namespaces
	* This can be done either by draging nodes around, or using the up and down buttons either in the tree view tool strip or on the right-click context menus for nodes
	* **Note**: Only the ordering of frames is actually saved at the moment. Reordering namespaces and sprites does not affect file output due to how sprite files are internally represented at the moment. See [Planned Features](#Planned-Features).
* Dragging nodes around
	* Dragging a frame onto a sprite removes the frame from its source sprite and adds it to the target sprite
	* Dragging a frame onto a frame swaps the frames
	* Draging a sprite onto a namespace moves the sprite (and its frames) into that namespace
	* Draging a namespace onto another namespace moves the namespace and all of its contents into the target namespace
	* The file itself counts as a namespace for destination purposes, but not source purposes - i.e. sprites and namespaces can be dragged onto the main file node, but the main file node cannot be used as a drag source
* All node entities can be deleted without issue
* All node entities can be duplicated
	* Pressing the 'duplicate' button will insert a copy of any frame, sprite or namespace directly below the original
* 'Zooming' in and out on the tree view, which changes the image list icon sizes from 16x16 to 32x32 and vice versa
* Individual frames can be exported in multiple formats: PNG, BMP, TIFF, GIF, ICO and JPEG

#### Tab Control

* Close multiple tabs
	* Close to the left
	* Close to the right
	* Close others
	* Close all
* Which files have been saved is tracked, as indicated by a floppy drive icon on each tab
* If you try to close an unsaved tab, you will be asked if you want to save it
	* This also occurs when closing the whole program

### Planned Features

These are features that are planned to appear in future versions, though I may not be actively working on them at the moment.

* Display the compression ration of compressed images
* Rotation of frames
* 'Rolling' frames around an axis
* Generating arrays for uncompressed frames
* More commenting

### Potential Features

These are features that aren't planned to be added in the immediate future, but are likely to occur some time in the long-term future

* Potential overhaul of internal representation/framework
* _Possibly_ the inclusion of a form of _limited_ 'undo' feature
* FX-related features
* Bundled licence texts

### Vetoed Features

Vetoed features are features that have been ruled out either in the short term or long term. A feature being on this list doesn't mean that it will _never_ happen, merely that it is considered either less important or (more likely) too much work to be implemented any time in the near future.

* Changing the format of the generated `.h` file
	* Purely because it means cluttering up the export form with everybody's favourite formatting options, and I worry about how many different options people will want if given the option.
* Saving and loading sprites to and from `.json` files instead of `.xml`
	* At the moment I can't be bothered to find or write a library that I like, and wouldn't consider it unless someone can demonstrate a suitable use case/requirement. I'm sorry if you don't like XML, but that was the easiest option given the tools I had available.
* Frame duplication generating a unique name
* Changing brush size
* Dither patterns
* Animation features of any kind
* Ensuring that frame dimensions are multiples of eight
	* The Arduboy library documentation claims this is a requirement, but `Sprites` has accomodated non-multiples-of-eight for at least 4-6 years, so I consider the documentation to be erroneous until proven otherwise

## Tutorial

To be added at a later date.

## Frequently Asked Questions

### Why does reordering namespaces and sprites not reorder them in the output file?

This is because of how sprites and namespaces are currently represented internally. I would like to fix this oversight at some point when I have settled upon the most appropriate solution.
