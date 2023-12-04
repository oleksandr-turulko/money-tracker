import ExpenseList from './ExpenseList';
import ExpenseForm from './ExpenseForm';

const HomePage = () => {
    return (
    <div style={{ width: "80%", margin: "auto" }}>
        
        <h3>New expense</h3>
        <ExpenseForm />
        <hr />
        <h3>Expenses</h3>
        <ExpenseList />
    </div>);
}

export default HomePage;