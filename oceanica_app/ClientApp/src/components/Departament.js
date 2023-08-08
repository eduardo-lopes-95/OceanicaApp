import React, { useState, useEffect } from "react";
import axios from 'axios';

const Departaments = () => {
    const [departaments, setdepartaments] = useState();

    const [id, setid] = useState();
    const [name, setname] = useState();
    const [vesselid, setvesselid] = useState();

    useEffect(() => {
        (async () => await GetDepartaments())();
    }, []);

    async function GetDepartaments() {
        const result = await axios.get("Departament/GetDepartaments");
        setdepartaments(result.data);
        console.log(result.data);
    }

    async function AddDepartament(event) {
        event.preventDefault();
        try {
            await axios.post("Departament/AddDepartament", {
                name: name,
                vesselid: vesselid,
            });
            alert("Departament added");

            setid("");
            setname("");
            setvesselid("")
            GetDepartaments();
        } catch (error) {
            alert(error);
        }
    }
    return (
        <div className="container">
            <h1>Departaments</h1>
            <div className="row">
                <form>
                    <div className="form-group">
                        <label>Departament Name</label>
                        <input
                            type="text"
                            className="form-control"
                            id="name"
                            value={name}
                            onChange={(event) => {
                                setname(event.target.value);
                            }}
                        />
                    </div>
                    <div className="form-group">
                        <label>Vessel Id</label>
                        <input
                            type="text"
                            className="form-control"
                            id="vesselId"
                            value={vesselid}
                            onChange={(event) => {
                                setvesselid(event.target.value);
                            }}
                        />
                    </div>
                    <div>
                        <button className="btn btn-primary" onClick={AddDepartament}>
                            Add
                        </button>
                    </div>
                </form>
            </div>
            <div className="row">
                <div className="col-12">
                    <table className="table table-bordered table-stripped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>Name</th>
                            </tr>
                        </thead>
                        {departaments?.map(function fn(departament) {
                            return (
                                <tbody>
                                    <tr>
                                        <th scope="row">{departament.id}</th>
                                        <td>{departament.name}</td>
                                    </tr>
                                </tbody>
                            );
                        })}
                    </table>
                </div>
            </div>
        </div>
    );
};

export default Departaments;