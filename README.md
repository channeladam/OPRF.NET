# OPRF.NET

Oblivious Pseudorandom Functions (OPRFs) using Prime-Order Groups.

## Overview

This library is an implementation of [VOPRF Internet Draft - Version 6](https://datatracker.ietf.org/doc/html/draft-irtf-cfrg-voprf-06.txt).

## .NET Targets

- .NET 5.0
- .NET Standard 2.1

## Dependencies

This library uses the popular, cross-platform, C-based library [libsodium](https://github.com/jedisct1/libsodium) for the implementation of ristretto255.

## Development Status

### Implemented Functionality

OPRF Protocol Modes:

- Base Mode

Cipher Suites:

- ristretto255, SHA-512

### Not Implemented

OPRF Protocol Modes:

- Verifiable Mode

Cipher Suites:

- decaf448, SHA-512
- P-256, SHA-256
- P-384, SHA-512
- P-521, SHA-512
