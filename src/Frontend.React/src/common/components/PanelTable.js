import React from 'react'

class PanelTable extends React.Component {
    render() {
        <div className="panel panel-default">

                <div className="panel-heading">Clients</div>
                <div className="panel-body">
                    <p>Below is a list of all the client accounts within your control. You can search for clients using the search filter. Use the buttons to view further details and update details.</p>
                </div>

                <table className="table table-striped table-responsive">
                    <ClientTableHead />
                    <ClientTableBody rows={this.props.rows} />
                </table>
            </div>
    }
}

export default PanelTable