import React, { useState, useEffect } from 'react';
import { Button } from 'react-bootstrap';
import { getData } from '../Service';
import CategoryModal from '../Componets/Modals/CategoryModal';
import CategoryEdit from '../Componets/Modals/CategoryEdit';
import { useTokenContext } from '../Store/AppContext';
import { Link } from 'react-router-dom';



const CategoryPage = () => {

    const hello = (v) => {
        console.log(v);
        setShowEdit(true)
    }
    // use context
    const token = useTokenContext();
    // local state
    //show
    const [show, setShow] = useState(false);
    const handleShow = () => setShow(true);
    //edit
    const [showEdit, setShowEdit] = useState(false);
    const handleShowEdit = () => {
        setShowEdit(true)
    };

    const [category, setCategory] = useState();

    const hideModal = () => {
        setShow(false);
    }
    const hideEditModal = () => {
        setShowEdit(false);
    }

    useEffect(() => {
        getData("api/system-configs/get-category", setCategory, token);
    }, [show]);


    return (
        <div className='container'>
            <Button className="btn" variant="secondary" onClick={handleShow}> Add</Button>
            <CategoryModal show={show} hideModal={hideModal} />
            <h4 className='mb-4'>Product Categories</h4>
            <table className='table table-bordered table-hover table-responsive-sm'>
                <thead>
                    <tr>
                        <th scope='col'>#</th>
                        <th scope='col'>Name</th>
                        <th scope='col'>Describe</th>
                        <th scope='col'>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        category && category.map((cat, index) => {
                            return (

                                < tr key={index}>
                                    <td > {cat.id}</td>
                                    <td>{cat.name}</td>
                                    <td>{cat.description}</td>
                                    <td>Action</td>
                                </tr>
                            )
                        })
                    }

                </tbody>
            </table >
        </div >
    );
}
export default CategoryPage;