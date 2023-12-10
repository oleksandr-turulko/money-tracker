import { React, useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { GetTransactions } from '../services/transactions';
import { Button, Row, Col } from 'react-bootstrap';
import TransactionForm from './TransactionForm';

const TransactionList = () => {
    const dispatch = useDispatch();
    const Transactions = useSelector(state => state.TransactionsSlice.Transactions);

    useEffect(() => {
        GetTransactions(dispatch);
    }, []);

    return Transactions.map(e =>
        <div key={e.id} style={{ marginBottom: '1rem' }}>
            <ListRow transaction={e} />
        </div>
    );
}

const ListRow = ({ transaction }) => {
    const [isEditing, setIsEditing] = useState(false);

    return isEditing
        ? <TransactionForm transaction={transaction} setIsEditing={setIsEditing} />
        : <div>
            <Row>
                <Col>{transaction.description}</Col>
                <Col>${transaction.amount}</Col>
                <Col>${transaction.date}</Col>
                <Col>${transaction.transactionType}</Col>
                <Col>${transaction.currency}</Col>
                <Button variant="warning" onClick={() => setIsEditing(!isEditing)}>Edit</Button>
            </Row>
            <hr />
        </div>
}

export default TransactionList;