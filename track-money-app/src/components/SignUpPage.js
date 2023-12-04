import { Form,FormControl, InputGroup, Button } from "react-bootstrap";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { SignUp } from "../services/auth";

const SignInPage = () => {

    const [email, setEmail] = useState('');
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
    const [confirmPassword, setConfirmPassword] = useState('');

    const dispatch = useDispatch();

    return <div style={{ width: '30rem', margin: 'auto', paddingTop: '8px' }}>
        <Form onSubmit={e=>{
            e.preventDefault();
            SignUp(dispatch,{email,username,password});
        }}>
            <h4 style={{ textAlign: 'center' }}>
                Welcome
            </h4>
            <InputGroup className="mb-3">
                <FormControl placeholder='Email' type='email'
                    onChange={e=>setEmail(e.target.value)}
                ></FormControl>
            </InputGroup>
            <InputGroup className="mb-3">
                <FormControl placeholder='Username' type='text'
                    onChange={e=>setUsername(e.target.value)}
                ></FormControl>
            </InputGroup>
            <InputGroup className="mb-3">
                <FormControl placeholder='Password' type='pasword'
                    onChange={e=>setPassword(e.target.value)}></FormControl>
            </InputGroup>
            <InputGroup className="mb-3">
                <FormControl placeholder='Confirm password' type='pasword'
                    onChange={e=>setConfirmPassword(e.target.value)}></FormControl>
            </InputGroup>
            <Button type='submit' variant='primary' style={{ margin: 'auto', display: 'block', width: '10rem' }} disabled={password !== confirmPassword || password.length <= 0}>Sign Up</Button>
        </Form>
    </div>
}

export default SignInPage;