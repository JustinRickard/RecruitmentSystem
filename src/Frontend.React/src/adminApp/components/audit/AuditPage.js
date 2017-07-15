import React from 'react';
import PropTypes from 'prop-types';
import {Link} from 'react-router';
import {connect} from 'react-redux';
import {bindActionCreators} from 'redux';
import * as auditActions from '../../actions/auditActions';
import text from '../../../common/text';

class AuditPage extends React.Component {

    render() {
        return (
            <div>
                <div className="col-md-3"></div>
                <div className="col-md-6">
                        <ol className="breadcrumb">
                            <li className="breadcrumb-item"><a href="">{text("generic.home")}</a></li>
                            <li className="breadcrumb-item active">{text("audit.audits")}</li>
                        </ol>
                        <h1>{text("audit.audits")}</h1>
                </div>
                <div className="col-md-3"></div>
            </div>
        );
    }
}

AuditPage.propTypes = {
    auditLogs: PropTypes.array.isRequired
}

function mapStateToProps(state, ownProps) {
    return {
        projects: state.auditLogs
    };
}

function mapDispatchToProps(dispatch) {
    return {
        actions: bindActionCreators(auditActions, dispatch)
    };
}

export default connect(mapStateToProps, mapDispatchToProps)(AuditPage);