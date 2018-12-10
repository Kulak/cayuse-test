if (!String.format) {
    String.format = function (format) {
        var args = Array.prototype.slice.call(arguments, 1);
        return format.replace(/{(\d+)}/g, function (match, number) {
            return typeof args[number] !== 'undefined'
                ? args[number]
                : match
                ;
        });
    };
}

class App extends React.Component {

    constructor(props) {
        super(props);
        this.state = { zipcode: "", description: "", newZipcode: "99037", status: "loading..." };
        this.loadLocation(this.state.newZipcode);
    }

    loadLocation(newZipcode) {
        const path = String.format('/api/location/descriptionbyzip/{0}', newZipcode);
        axios.get(path)
            .then(response => {
                // console.log("response", response);
                let newState = { zipcode: newZipcode, description: response.data, newZipcode: newZipcode, status: "ok" };
                this.setState(newState);
            })
            .catch(response => {
                console.error(response.message);
                this.setState(Object.assign(this.state, {status: "not a valid zipcode"}))
            });
    }

    handleZipCodeChange = (event) => {
        let newZipCode = event.target.value;
        this.setState(Object.assign(this.state, {newZipcode: newZipCode, status: "loading..."}));
        this.loadLocation(newZipCode);
    }

    render() {
        let state = this.state;
        return (
            <div>
                <h1>Location Description</h1>
                <p>Zip code: <input type="text" value={state.newZipcode} onChange={this.handleZipCodeChange} /></p>
                <p>Status: {state.status}</p>
                <h2>Status</h2>
                <p>Zip code: {state.zipcode}</p>
                <p>Description: {state.description}</p>
            </div>
        );
    }

}

ReactDOM.render(
    <App/>,
    document.getElementById('app')
);
