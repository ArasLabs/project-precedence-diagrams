# Project Precedence Diagram Reports

Draws Precedence Diagram as Scalable Vector Graphics (SVG) which can be panned, zoomed and searched. It can also be printed to multiple pages using a client control.

Diagrams with dates and day number are included, day number is useful for understanding how the dates are calculated.

Adobe SVG Viewer is required on the client and GraphViz from GraphViz.org is required on the server; both are free downloads. Steps for installation are included in the .ReadMe.txt file in the download.

Diagrams can be customized using SQL stored procedures to generate the GraphViz dot language, for which documentation is at the GraphViz site.

SVG diagrams from other sources can also be displayed by the ShowPrintSVG.aspx page.

## History

This project and the following release notes have been migrated from the old Aras Projects page. Unlike community projects that have been migrated and archived, this project will be updated for compatibility with the latest release of Aras Innovator.

Release | Notes
--------|--------
[v1](https://github.com/ArasLabs/project-precedence-diagrams/releases/tag/v1) | Initial release

#### Supported Aras Versions

Project | Aras
--------|------
[v1](https://github.com/ArasLabs/project-precedence-diagrams/releases/tag/v1) | 8.1.1

## Installation

#### Important!
**Always back up your code tree and database before applying an import package or code tree patch!**

### Pre-requisites

1. Aras Innovator installed (version 8.1.1)
2. Aras Package Import tool
3. **com.aras.innovator.solution.SVGDiagrams** import package
4. **project-precedence-diagrams** code tree overlay

### Install Steps

1. Backup your code tree and store the backup in a safe place.
2. Copy the Innovator folder from the project's CodeTree subdirectory.
3. Paste the Innovator folder into the root directory of your Aras installation.
  * Tip: This is the same directory that contains the InnovatorServerConfig.xml file.
4. Backup your database and store the BAK file in a safe place.
5. Open up the Aras Package Import tool.
6. Enter your login credentials and click **Login**
  * _Note: You must login as root for the package import to succeed!_
7. Enter the package name in the TargetRelease field.
  * Optional: Enter a description in the Description field.
8. Enter the path to your local `..\project-precedence-diagrams\Import\imports.mf` file in the Manifest File field.
9. Select **com.aras.innovator.solution.SVGDiagrams** in the Available for Import field.
10. Select Type = **Merge** and Mode = **Thorough Mode**.
11. Click **Import** in the top left corner.
12. Close the Aras Package Import tool.

## Usage

See [InstallSVGDiagrams.ReadMe.txt](./Documentation/InstallSVGDiagrams.ReadMe.txt) for more information on using this project.

## Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request

For more information on contributing to this project, another Aras Labs project, or any Aras Community project, shoot us an email at araslabs@aras.com.

## Credits

Created by Jon Hodge for Aras Corporation.

## License

Aras Labs projects are published to Github under the MIT license. See the [LICENSE file](./LICENSE.md) for license rights and limitations.
