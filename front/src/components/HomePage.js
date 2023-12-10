import TransactionList from './TransactionList';
import TransactionForm from './TransactionForm';
import { ToastContainer } from 'react-toastify';

const HomePage = () => (
    <div style={{ width: '60%', margin: 'auto' }}>
        <ToastContainer />
        <h4>New Transaction</h4>
        <TransactionForm />
        <hr style={{ border: '1px solid grey' }} />
        <h4>Your Transactions</h4>
        <TransactionList />
    </div>
);

export default HomePage;