---
title: NBS banking cao service v1
language_tabs:
  - shell: Shell
  - http: HTTP
  - javascript: JavaScript
  - ruby: Ruby
  - python: Python
  - php: PHP
  - java: Java
  - go: Go
toc_footers: []
includes: []
search: true
highlight_theme: darkula
headingLevel: 2

---

<!-- Generator: Widdershins v4.0.1 -->

<h1 id="nbs-banking-cao-service">NBS banking cao service v1</h1>

> Scroll down for code samples, example requests and responses. Select a language for code samples from the tabs above or the mobile navigation menu.

NBS Banking,  cao orchestration API

<h1 id="nbs-banking-cao-service-caoorchestration">CaoOrchestration</h1>

## Retrive application status for specified application id

`GET /api/v1/caoorchestration/{appId}/auditlogs`

<h3 id="retrive-application-status-for-specified-application-id-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|appId|path|string|true|unique identifier of the application to be retrived.|

> Example responses

> 200 Response

```json
{
  "responsePayload": [
    {
      "logId": "string",
      "accessTokens": "string",
      "appId": "string",
      "deferUntil": "2019-08-24T14:15:22Z",
      "retryCount": 0,
      "lastAction": "string",
      "status": "string",
      "isActive": true,
      "auditReference": "5055b1e7-eae9-4d10-b639-cb5e9dec4e4c",
      "lastUpdatedDatetime": "2019-08-24T14:15:22Z",
      "lastUpdatedBy": "string",
      "rowVersion": "string",
      "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
      "lastModifiedBy": "string",
      "version": "string"
    }
  ],
  "status": {
    "code": 0,
    "retry": true,
    "type": 0,
    "message": "string"
  }
}
```

<h3 id="retrive-application-status-for-specified-application-id-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Specified application audit log was retrieved sucessfully|[ApplicationRequestAuditLogListResponsePayload](#schemaapplicationrequestauditloglistresponsepayload)|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Incorrect App Id|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|No record found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|An unexpected fault happened. Try again later|None|

<aside class="success">
This operation does not require authentication
</aside>

## Retrive the number of applications sucessfully enlisted.

`GET /api/v1/caoorchestration/{appId}/enlist`

<h3 id="retrive-the-number-of-applications-sucessfully-enlisted.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|appId|path|string|true|none|
|x-Journey-Id|header|string|false|none|

<h3 id="retrive-the-number-of-applications-sucessfully-enlisted.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successfully enlisted|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Incorrect App Id or Journey-id|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|No record found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|An unexpected fault happened. Try again later|None|

<aside class="success">
This operation does not require authentication
</aside>

## Resume the application orchestration

`GET /api/v1/caoorchestration/{appId}/resume`

<h3 id="resume-the-application-orchestration-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|appId|path|string|true|application id|
|x-Journey-Id|header|string|false|Journey id|

<h3 id="resume-the-application-orchestration-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successfully resumed|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Incorrect App Id or Journey-id|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Access was denied for this operation|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|No record found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|An unexpected fault happened. Try again later|None|

<aside class="success">
This operation does not require authentication
</aside>

## cancels orchestration of the requested application.

`POST /api/v1/caoorchestration/{appId}/cancel`

<h3 id="cancels-orchestration-of-the-requested-application.-parameters">Parameters</h3>

|Name|In|Type|Required|Description|
|---|---|---|---|---|
|x-Journey-Id|header|string|false|unique journey identifier associated with the cao queue entry.|
|appId|path|string|true|unique identifier of application associated with the cao queue entry|
|rv|query|string|false|row version|

<h3 id="cancels-orchestration-of-the-requested-application.-responses">Responses</h3>

|Status|Meaning|Description|Schema|
|---|---|---|---|
|200|[OK](https://tools.ietf.org/html/rfc7231#section-6.3.1)|Successfully cancelled the application request|None|
|400|[Bad Request](https://tools.ietf.org/html/rfc7231#section-6.5.1)|Incorrect request state OR parameters|None|
|403|[Forbidden](https://tools.ietf.org/html/rfc7231#section-6.5.3)|Access was denied for this operation|None|
|404|[Not Found](https://tools.ietf.org/html/rfc7231#section-6.5.4)|No record found|None|
|500|[Internal Server Error](https://tools.ietf.org/html/rfc7231#section-6.6.1)|An unexpected fault happened. Try again later|None|

<aside class="success">
This operation does not require authentication
</aside>

# Schemas

<h2 id="tocS_ApplicationRequestAuditLog">ApplicationRequestAuditLog</h2>
<!-- backwards compatibility -->
<a id="schemaapplicationrequestauditlog"></a>
<a id="schema_ApplicationRequestAuditLog"></a>
<a id="tocSapplicationrequestauditlog"></a>
<a id="tocsapplicationrequestauditlog"></a>

```json
{
  "logId": "string",
  "accessTokens": "string",
  "appId": "string",
  "deferUntil": "2019-08-24T14:15:22Z",
  "retryCount": 0,
  "lastAction": "string",
  "status": "string",
  "isActive": true,
  "auditReference": "5055b1e7-eae9-4d10-b639-cb5e9dec4e4c",
  "lastUpdatedDatetime": "2019-08-24T14:15:22Z",
  "lastUpdatedBy": "string",
  "rowVersion": "string",
  "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
  "lastModifiedBy": "string",
  "version": "string"
}

```

Represents a change to the CAO queue item

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|logId|string¦null|false|none|Unique identifier of the audit log record<br>This is same as the rowversion of the audited record|
|accessTokens|string¦null|false|none|metadata / summary of the Access token in original record|
|appId|string|true|none|Unique identifier of the Application associated with the queue item|
|deferUntil|string(date-time)|false|none|an absolute point in time until which this queue item should not be processed.|
|retryCount|integer(int32)|false|none|number of times the last action has been retried for this queue item.|
|lastAction|string¦null|false|none|Last Action that was performed on this item.|
|status|string¦null|false|none|status of the LastAction performed on this record.|
|isActive|boolean|false|none|flag indicating if the request is being active for orchestration|
|auditReference|string(uuid)|false|none|unique guid that can identifiy a set of records associated with a single database operation.|
|lastUpdatedDatetime|string(date-time)|false|none|timestamp when the record was last updated|
|lastUpdatedBy|string¦null|false|none|string indicating the identity causing the update.|
|rowVersion|string¦null|false|none|sql row version of the record|
|id|string(uuid)|false|none|none|
|lastModifiedBy|string¦null|false|none|none|
|version|string¦null|false|none|none|

<h2 id="tocS_ResponsePayloadType">ResponsePayloadType</h2>
<!-- backwards compatibility -->
<a id="schemaresponsepayloadtype"></a>
<a id="schema_ResponsePayloadType"></a>
<a id="tocSresponsepayloadtype"></a>
<a id="tocsresponsepayloadtype"></a>

```json
0

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|*anonymous*|integer(int32)|false|none|none|

#### Enumerated Values

|Property|Value|
|---|---|
|*anonymous*|0|
|*anonymous*|1|
|*anonymous*|2|

<h2 id="tocS_ResponseStatus">ResponseStatus</h2>
<!-- backwards compatibility -->
<a id="schemaresponsestatus"></a>
<a id="schema_ResponseStatus"></a>
<a id="tocSresponsestatus"></a>
<a id="tocsresponsestatus"></a>

```json
{
  "code": 0,
  "retry": true,
  "type": 0,
  "message": "string"
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|code|integer(int32)|false|none|none|
|retry|boolean|false|none|none|
|type|[ResponsePayloadType](#schemaresponsepayloadtype)|false|none|none|
|message|string¦null|false|none|none|

<h2 id="tocS_ApplicationRequestAuditLogListResponsePayload">ApplicationRequestAuditLogListResponsePayload</h2>
<!-- backwards compatibility -->
<a id="schemaapplicationrequestauditloglistresponsepayload"></a>
<a id="schema_ApplicationRequestAuditLogListResponsePayload"></a>
<a id="tocSapplicationrequestauditloglistresponsepayload"></a>
<a id="tocsapplicationrequestauditloglistresponsepayload"></a>

```json
{
  "responsePayload": [
    {
      "logId": "string",
      "accessTokens": "string",
      "appId": "string",
      "deferUntil": "2019-08-24T14:15:22Z",
      "retryCount": 0,
      "lastAction": "string",
      "status": "string",
      "isActive": true,
      "auditReference": "5055b1e7-eae9-4d10-b639-cb5e9dec4e4c",
      "lastUpdatedDatetime": "2019-08-24T14:15:22Z",
      "lastUpdatedBy": "string",
      "rowVersion": "string",
      "id": "497f6eca-6276-4993-bfeb-53cbbbba6f08",
      "lastModifiedBy": "string",
      "version": "string"
    }
  ],
  "status": {
    "code": 0,
    "retry": true,
    "type": 0,
    "message": "string"
  }
}

```

### Properties

|Name|Type|Required|Restrictions|Description|
|---|---|---|---|---|
|responsePayload|[[ApplicationRequestAuditLog](#schemaapplicationrequestauditlog)]¦null|false|none|[Represents a change to the CAO queue item]|
|status|[ResponseStatus](#schemaresponsestatus)|false|none|none|

