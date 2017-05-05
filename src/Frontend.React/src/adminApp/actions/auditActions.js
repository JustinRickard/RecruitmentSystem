import actionTypes from '../common/actionTypes';

export function getAuditLogs(filter) {
    return {
        type: actionTypes.AuditLogsGet,
        filter
    }
}