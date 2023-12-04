import { Form,FormControl, InputGroup, Button } from "react-bootstrap";
import { useState } from "react";
import { useDispatch } from "react-redux";
import { SignIn } from "../services/auth";

const SignInPage = () => {

    const [email, setEmail] = useState('');
    const [password, setPassword] = useState('');
    const dispatch = useDispatch();

    return <div style={{ width: '30rem', margin: 'auto', paddingTop: '8px' }}>
        <Form onSubmit={e=>{
            e.preventDefault();
            SignIn(dispatch,{email,password});
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
                <FormControl placeholder='Password' type='password'
                    onChange={e=>setPassword(e.target.value)}></FormControl>
            </InputGroup>
            <Button type='submit' variant='primary' style={{ margin: 'auto', display: 'block', width: '10rem' }}>Sign In</Button>
        </Form>
    </div>
}

export default SignInPage;