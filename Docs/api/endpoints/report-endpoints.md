# Report Endpoints

## Overview
The Report API provides endpoints for generating various statistical reports and analytics about the system's usage.

## Base URL
    `/api/Report`

## Endpoints

### Get General Statistics
Retrieves general statistics about the system.

``GET``: /api/Report/general

Headers:
    ``Authorization``: Bearer Token (Admin only)


### Get Statistics by Date Range
Retrieves answer statistics within a specified date range.

``GET``: /api/Report/by-date-range

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``startDate`` (query): Start date for the range
    ``endDate`` (query): End date for the range


### Get Destination Statistics
Retrieves statistics about destinations.

``GET``: /api/Report/destinations

Headers:
    ``Authorization``: Bearer Token (Admin only)

### Get User Activity Statistics
Retrieves statistics about user activity.

``GET``: /api/Report/user-activity

Headers:
    ``Authorization``: Bearer Token (Admin only)

### Get Statistics by Category
Retrieves statistics for a specific question category.

``GET``: /api/Report/by-category/{category}

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``category`` (path): The category to get statistics for

### Get Paginated Report
Retrieves paginated report data.

``GET``: /api/Report/paginated

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``page`` (query): Page number (default: 1)
    ``pageSize`` (query): Items per page (default: 10)

### Get Trending Destinations
Retrieves trending destinations over a specified period.

``GET``: /api/Report/trending

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``days`` (query): Number of days to analyze (default: 30)

### Get Filtered Report
Retrieves report data with multiple filter options.

``GET``: /api/Report/filtered

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``startDate`` (query, optional): Start date filter
    ``endDate`` (query, optional): End date filter
    ``category`` (query, optional): Category filter
    ``cityName`` (query, optional): City name filter

### Get Monthly Comparison
Retrieves statistical comparison for a specific month.

``GET``: /api/Report/monthly-comparison

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``month`` (query): Month number (1-12)
    ``year`` (query): Year

### Export Report
Exports report data in different formats.

``GET``: /api/Report/export

Headers:
    ``Authorization``: Bearer Token (Admin only)

Parameters:
    ``format`` (query): Export format (default: "excel")

Response:
    Content-Type: application/vnd.openxmlformats-officedocument.spreadsheetml.sheet
    File: report.xlsx

### Error Responses
- ``200 OK``: Successful response
- ``400 Bad Request``: Invalid input parameters
- ``401 Unauthorized``: Authentication required
- ``403 Forbidden``: Insufficient permissions (Admin only)
- ``500 Internal Server Error``: Server error