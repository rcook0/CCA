# Domain Language (Draft — non-binding)

This document defines the shared vocabulary for the CCA/MyCCA codebase.
It is descriptive first; it becomes prescriptive only when explicitly adopted.

## Current Reality (as implemented)
- `User` is a person record with a global `Role` string.
- `Application` is a structured process tied to a `UserId` and a `TargetEntityId`.
- `Milestone` and `Decision` are collections owned by `Application`.
- `TargetEntity` represents what is being pursued (currently defaulting to "College").
- `Assessment` represents an evaluation artifact.

## Preferred Domain Terms (aliases; code names remain unchanged for now)
- Person = `User`
- Journey (Case/Track) = `Application`
- Target = `TargetEntity`
- Step = `Milestone`
- Outcome Event = `Decision`
- Evaluation = `Assessment`

## Roles (legacy → generalized)
Legacy roles are treated as a compatibility layer:
- Student → Participant
- Counselor → Advisor
- Admin → Admin

Rules:
- v1 endpoints remain in legacy terms.
- v2 endpoints speak generalized terms.

## Boundaries and invariants (must stay true)
- Decisions are append-only events. Never rewrite history; add a new Decision.
- A Journey owns its Milestones and Decisions (cascade delete acceptable).
- A Target is a first-class entity and should not be hard-coded to College.
- v1 compatibility routes continue to function until intentionally removed.

## Explicitly undecided (do not implement yet)
- Whether `Application` should be renamed in code (Journey) or only aliased.
- Whether all Journeys must have a Target.
- Whether roles should become per-Organization memberships (Phase 2) or remain global.
- Whether multi-tenancy is hard isolation (separate schemas) or soft isolation (org_id).