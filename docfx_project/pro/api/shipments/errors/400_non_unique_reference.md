---
uid: pro-api-shipments-errors-400-non-unique-reference
title: 400 - Non-Unique Reference
tags: v2,validation,pro,api,shipments,error,400
contributors: andy.walton@sorted.com
created: 13/11/2020
---
# 400 - Non-Unique Reference

* **Parent Error Code** - `400 validation_error`
* **Description** - The provided reference matches more than one entity, e.g. it matches both a specific carrier service *and* and carrier service group when allocating with a "virtual" carrier service.