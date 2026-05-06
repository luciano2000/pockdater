# Changelog

All notable changes to Pockdater are documented in this file.

## [1.0.0] - 2026-05-06

### Summary

Initial release of **Pockdater** — a fork of [pupdate](https://github.com/mattpannella/pupdate) (v4.11.0) by Matt Pannella, rebased with bug fixes and reliability improvements.

### Bug Fixes

- **Atomic file downloads** (`HttpHelper.DownloadFile`): Downloads now write to a temporary `.tmp` file and only rename to the final destination path upon successful completion. Previously, an interrupted download left a corrupt partial file at the output path. Temporary files are cleaned up on any error.

- **Retry logic with exponential backoff** (`HttpHelper.DownloadFile`): Failed downloads are now retried up to 3 times with exponential backoff (1 second, 2 seconds, 4 seconds). HTTP 404 errors and invalid URI errors are not retried, as they are not transient failures.

- **ZipHelper file handle leak** (`ZipHelper.ExtractToDirectory`): `FileStream` and `ZipArchive` are now wrapped in `using` statements. Previously, if extraction raised an exception, the file handles were never released, preventing the caller from deleting or moving the archive file.

- **Backup-restore for `ChangeAspectRatio` and `ClearDisplayModes`** (`CoresService.Video`): Both methods now use the same `WriteVideoJsonSafe` helper that `AddDisplayModes` already used (the fix for upstream issue #354). This prevents `video.json` corruption when a write fails mid-way due to disk-full or similar I/O errors.

- **Atomic instance JSON writes** (`CoresService.BuildInstanceJson`): Instance JSON files are now written to a `.tmp` file first and then renamed to the final path. This avoids leaving a half-written JSON file if the process is killed during the write.

- **Configurable download timeout**: The per-file download timeout was previously hardcoded to 100 seconds at the call site. It is now exposed as `download_timeout_seconds` in `pockdater_settings.json` (default: 100). The setting is applied at startup and after settings reload.

### Changed

- Project renamed from `pupdate` to `pockdater`.
- Namespace changed from `Pannella` to `Pockdater`.
- Settings file renamed from `pupdate_settings.json` to `pockdater_settings.json` (old filename migrated automatically on first run).
- Version reset to `1.0.0`.
- Repository URLs updated to `lucianorocha/pockdater`.

### Credits

All core functionality was built by **Matt Pannella** and the pupdate contributors. This fork preserves 100% of the original feature set and adds the reliability fixes listed above.
