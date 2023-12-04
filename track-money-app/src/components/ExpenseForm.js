import { React, useEffect, useState } from 'react';
import { Form, Row, Col, Button } from 'react-bootstrap';
import { DeleteExpense, EditExpense, NewExpense } from '../services/expenses';
import { useDispatch } from 'react-redux';

export default ({ expense, setIsEditing }) => {
    const descriptions = ['products', 'card', 'loans', 'gas'];
    const expenseOrIncome = ['expense', 'income'];
    const currencies = ['UAH', 'USD', 'EUR'];
    const [amount, setAmount] = useState(0);
    const [description, setDescription] = useState(descriptions[0]);
    const [typeOfTransaction, setTypeOfTransaction] = useState(expenseOrIncome[0]);
    const [currency, setCurrency] = useState(currencies[0]);

    const [isNewExpense, setIsNewExpense] = useState(true);
    const dispatch = useDispatch();

    useEffect(() => {
        if (expense !== undefined) {
            setIsNewExpense(false);
            setAmount(expense.amount);
        }
        else {
            setIsNewExpense(true);
        }
    }, [expense]);

    return <Form
        onSubmit={e => {
            e.preventDefault();
            if (isNewExpense) {
                //add
                NewExpense(dispatch, 
                    {
                        description: description, 
                        amount: amount, 
                        typeOfTransaction: typeOfTransaction,
                        currency: currency
                    });
            }
            else {
                //edit
                EditExpense(dispatch, { id: expense.id, description: description, amount: amount, typeOfTransaction: typeOfTransaction });
                setIsEditing(false);
            }
        }}
    >
        <Row>
            <Col>
                <Form.Label>Description</Form.Label>
                <Form.Control as='select'
                    onChange={e => {
                        setDescription(e.target.value)
                    }}>
                    {descriptions.map(d => <option>{d}</option>)}
                </Form.Control>
            </Col>
            <Col>
                <Form.Label>Amount</Form.Label>
                <Form.Control
                    type='number'
                    step='0.01'
                    placeholder={amount}
                    onChange={e => setAmount(e.target.value)}
                ></Form.Control>
            </Col>
            <Col>
                <Form.Label>Type of transaction</Form.Label>
                <Form.Control as='select'
                    onChange={e => setTypeOfTransaction(e.target.value)}
                >{expenseOrIncome.map(eoi => <option>{eoi}</option>)}</Form.Control>
            </Col>
            <Col>
                <Form.Label>Currency</Form.Label>
                <Form.Control as='select'
                    onChange={e => setCurrency(e.target.value)}
                >{currencies.map(c => <option>{c}</option>)}</Form.Control>
            </Col>
            <Col style={{ marginTop: "auto" }}>
                {isNewExpense
                    ? <Button variant='primary' type='submit'>Add</Button>
                    : <div>
                        <Button variant='danger' onClick={() => {
                            DeleteExpense(dispatch, expense);
                        }}>Delete</Button>
                        <Button variant='success' type="submit">Save</Button>
                        <Button variant='default' onClick={() => setIsEditing(false)
                        }>Cancel</Button>
                    </div>

                }
            </Col>
        </Row>
    </Form>
}