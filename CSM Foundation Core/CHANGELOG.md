# CSM Foundation Core CHANGELOG

## [3.0.0] - 25.12-2025

### Remved

- Removed from errors model [ErrorInfo] since it was only needed when internal errors are exposed to connected services with critical information.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

## [2.1.1] - 24.12-2025

### Changed

- Changed a SystemUtils method [SetVar] to allow env context target.

### Added

- Added a new method to [SystemUtils] named [GetGlobalVar] that maps all available environment variables target contexts to get the value.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

## [2.1.0] - 22.12-2025

### Changed

- Changed a SystemUtils method [GetVar] to allow env context target.

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

## [2.0.0] - 24.11-2025

### Changed

- Renamed and reorganized the project structure to CSM Foundation Core to better reflect its purpose as a foundational library for CSM systems.
- Changed concept from [Exception] to [Error].

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

### Removed

## [1.3.0] - 27.08-2025

### Added

- Added a new [IDIsposer] interface used for disposition managers implementations at CSM systems.

### Fixed

### Changed

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

### Removed

## [1.2.3] - 27.08-2025

### Added

#### [SystemUtils]

- Added a new method (GetEnv) that gets and returns the current system runtime environment scope.

### Fixed

### Changed

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

### Removed

## [1.2.2] - 13.08-2025

### Added

- [XSystem] a generic base CSM framework exception for the integrated exception management.

### Fixed

### Changed

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

### Removed

- [IException] interface "subject" property got removed to use native .Net Excetion class Message property.

## [1.2.1] - 13.08-2025

### Added

- [SystemUtils] class that handles easier the way that env vars can be handled.

### Fixed

### Changed

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

### Removed

## [1.1.1] - 06.08-2025

### Added

- [ConsoleUtils] class was added to handle better console printing information.

### Fixed

### Changed

#### Dependencies

| Package                                 | Previous Version | New Version     |
|:----------------------------------------|:----------------:|:---------------:|
|                                         |                  |                 |

### Removed
